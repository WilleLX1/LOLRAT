import platform

# Get system information
system_info = {
    "System": platform.system(),
    "Node Name": platform.node(),
    "Release": platform.release(),
    "Version": platform.version(),
    "Machine": platform.machine(),
    "Processor": platform.processor(),
}

# Print the system information
for key, value in system_info.items():
    print(f"{key}: {value}")
