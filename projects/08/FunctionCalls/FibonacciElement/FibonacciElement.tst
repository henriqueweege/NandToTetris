// This file is part of www.nand2tetris.org
// and the book "The Elements of Computing Systems"
// by Nisan and Schocken, MIT Press.
// File name: projects/08/FunctionCalls/FibonacciElement/FibonacciElement.tst

// Tests FibonacciElement.asm on the CPU emulator. 
// FibonacciElement.asm results from translating both Main.vm and Sys.vm into
// a single assembly program, stored in the file FibonacciElement.asm.

load FibonacciElement.asm,
output-file FibonacciElement.out,
compare-to FibonacciElement.cmp,
set RAM[0] 256,  // initializes the stack pointer 
set RAM[1] 100,  // initializes the lcl pointer 
set RAM[2] 130,  // initializes the arg pointer 
set RAM[3] 190,  // initializes the this pointer 
set RAM[4] 220,  // initializes the that pointer 

repeat 6000 {
	ticktock;
}

// Outputs the stack pointer and the value at the stack's base.
output-list RAM[0]%D1.6.1 RAM[261]%D1.6.1;
output;
