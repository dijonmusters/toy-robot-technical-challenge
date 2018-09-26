# Toy Robot Simulator
## REA Technical Challenge

### Install Dependencies
Download and install OS specific dotnet
```https://www.microsoft.com/net/download```

If you're running macOS you may need to create a symbolic link for the cli command
```ln -s /usr/local/share/dotnet/dotnet /usr/local/bin/```

### Prepare Project
Uncompress package with CLI
```tar -xvzf REA_toy_robot_v5.tar.gz```

Change into the project's directory
```cd ToyRobot```

### Run Simulator
Run simulator from CLI
```dotnet run -p ToyRobot```

Run tests from CLI
```dotnet test ToyRobot.Tests```
