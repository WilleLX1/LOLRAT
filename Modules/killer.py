import psutil
import sys
import pygetwindow as gw
import os

def get_pid_by_window_title(title):
    current_pid = os.getpid()  # Get the PID of the current process

    for proc in psutil.process_iter(['pid', 'name', 'cmdline']):
        if proc.info['pid'] != current_pid and proc.info['name'] == 'python.exe' and title in proc.info['cmdline']:
            return proc.info['pid']

    return None

def print_python_processes():
    for proc in psutil.process_iter(['pid', 'name', 'cmdline']):
        if proc.info['name'] == 'python.exe':
            # Get the process by PID
            proc = psutil.Process(proc.info['pid'])

            # Print process details
            print(f"\nPID: {proc.pid}")
            print(f"Process Name: {proc.name()}")
            print(f"Process Status: {proc.status()}")
            print(f"Process Parent ID: {proc.ppid()}")
            print(f"Process Parent Name: {psutil.Process(proc.ppid()).name()}")
            print(f"Process Creation Time: {proc.create_time()}")
            print(f"Memory Info: {proc.memory_info()}")
            print(f"CPU Times: {proc.cpu_times()}")
            print(f"Command Line: {' '.join(proc.cmdline())}")


if __name__ == '__main__':
    if len(sys.argv) != 2:
        print('Usage: python killer.py <WindowName>')
        sys.exit(1)
    
    window_title = sys.argv[1]

    # Get the PID of the Python process running the script
    pid = get_pid_by_window_title(window_title)
    
    print_python_processes()

    if pid is None:
        print(f"No Python process found running script with window title '{window_title}'.")
        sys.exit(1)

    # Get the process by PID
    proc = psutil.Process(pid)

    # Print process details
    print(f"PID: {proc.pid}")
    print(f"Process Name: {proc.name()}")
    print(f"Process Status: {proc.status()}")
    print(f"Process Parent ID: {proc.ppid()}")
    print(f"Process Parent Name: {psutil.Process(proc.ppid()).name()}")
    print(f"Process Creation Time: {proc.create_time()}")
    print(f"Memory Info: {proc.memory_info()}")
    print(f"CPU Times: {proc.cpu_times()}")
    print(f"Command Line: {' '.join(proc.cmdline())}")

