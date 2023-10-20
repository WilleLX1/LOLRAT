import subprocess
import sys

# Check if a command argument is provided
if len(sys.argv) != 2:
    print("Usage: python script.py <command>")
    sys.exit(1)

# Get the command from the command-line argument
command = sys.argv[1]

# Use the subprocess.run() function to run the specified command and capture the output
result = subprocess.run(command, shell=True, stdout=subprocess.PIPE, stderr=subprocess.PIPE, text=True)

# Check the return code to see if the command was successful
if result.returncode == 0:
    print(f"Output:\n{result.stdout}")
else:
    print(f"Error:\n{result.stderr}")
