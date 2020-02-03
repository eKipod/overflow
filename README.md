# Overflow Calculator

A tool to find the volume of a glass in a pyramid.

## Build and Run

### .NET CLI

1. Build

```
	dotnet test "overflow.test\overflow.test.csproj" -c Release

	dotnet publish "overflow.exe\overflow.exe.csproj" -c Release -o bin
```

2. Run

```
	dotnet bin\overflow.exe.dll --row 3 --index 2 --poured 10
```

```
	dotnet bin\overflow.exe.dll --row 3 --index 2 --poured 10 --verbose
```

### Docker

1. Create image
```
	docker build -f "overflow.exe\Dockerfile" . -t overflow:dev
```

2. Run image
```
	docker run -t overflow:dev -- --row 3 --index 2 --poured 10
```

### Usage

```
Calculate the volume of a glass in a glass pyramid:
  overflow.exe --index 2 --poured 10 --row 3

  -r, --row       Required. Row for which to calculate volume (first row is 0).

  -i, --index     Required. Index of the glass in the row for which to calculate
                  volume (first index is 0).

  -p, --poured    Required. Amount poured (in liters) to the top of the glass
                  pyramid.

  --help          Display this help screen.

  --version       Display version information.
```
