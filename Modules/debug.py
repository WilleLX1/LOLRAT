import subprocess

# Use the subprocess.run() function to run the 'whoami' command and capture the output
command = 'whoami'
result = subprocess.run(command, shell=True, stdout=subprocess.PIPE, stderr=subprocess.PIPE, text=True)

# Check the return code to see if the command was successful
if result.returncode == 0:
    print(f"Output:\n{result.stdout}")
else:
    print(f"Error:\n{result.stderr}")