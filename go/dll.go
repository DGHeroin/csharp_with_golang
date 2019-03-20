package main

/*
#include <stdio.h>
#include <stdlib.h>
typedef int (__stdcall * Callback)(const char* text);
static Callback callback;
static void Call(void* ptr) {
    callback = (Callback) ptr;
}
static void Invoke(const char* text) {
    if (callback != NULL) {
        callback(text);
    }
}
*/
import "C"
import (
    "unsafe"
    "time"
)

//export SetCallback
func SetCallback(ptr unsafe.Pointer) {
    C.Call(ptr)
}
//export StartGoTimer
func StartGoTimer() {
    ticker := time.NewTicker(time.Second)
    for range ticker.C {
        invokeCallback("Hello CSharp!")
    }
}

//export TestCallback
func TestCallback(text *C.char) {
    msg := C.GoString(text)
    invokeCallback(msg)
}

func invokeCallback(str string) {
    cstr := C.CString(str)
    C.Invoke(cstr)
    C.free(unsafe.Pointer(cstr))
}

func main()  {
}