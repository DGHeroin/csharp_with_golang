set GOARCH=amd64
set CGO_ENABLED=1
go build -o go.dll -buildmode=c-shared
