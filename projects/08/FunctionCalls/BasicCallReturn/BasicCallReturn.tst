load BasicCallReturn.asm,
output-file BasicCallReturn.out,
set RAM[0] 256,  // initializes the stack pointer 
set RAM[1] 100,  // initializes the lcl pointer 
set RAM[2] 130,  // initializes the arg pointer 
set RAM[3] 190,  // initializes the this pointer 
set RAM[4] 220,  // initializes the that pointer 

repeat 6000 {
	ticktock;
}