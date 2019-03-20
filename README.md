# csharp with golang
## Step 1
编译go dll (自行配置好cgo编译环境), 本例中使用x86_64-8.1.0-posix-seh-rt_v6-rev0
```
set GOARCH=amd64
set CGO_ENABLED=1
go build -o go.dll -buildmode=c-shared
```

## Step 2
1.创建一个c#项目，把生成目标改成x64。(解决方案->项目->属性->生成->平台目标->x64)
2.运行, 令其产生bin\Debug目录。
2.把step 1中生成go.dll拷贝到bin\Debug中即可。

## Step 3
编译运行c#
