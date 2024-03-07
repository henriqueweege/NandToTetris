// function Sys.init 0

                      (Sys.init)
                      
                        
// 	push constant 4

                        @4
                        D=A
                        @SP
                        A = M
                        M = D
                        
                    //increment pointer
                    @SP
                    M = M + 1
// 	call Main.fibonacci 1   // computes the 4'th fibonacci element

                     //push return address
                     
                    @ReturnAddress-1
                    D=A
                    @SP
                     A = M
                     M = D 
                     
                    //increment pointer
                    @SP
                    M = M + 1
                     
                     //save LCL
                     @LCL
                     D = M
                     @SP
                     A = M
                     M = D 
                     
                    //increment pointer
                    @SP
                    M = M + 1
                    //save ARG 
                     @ARG
                     D = M
                     @SP
                     A = M
                     M = D 
                     
                    //increment pointer
                    @SP
                    M = M + 1
                    //save THIS
                     @THIS
                     D = M
                     @SP
                     A = M
                     M = D 
                     
                    //increment pointer
                    @SP
                    M = M + 1
                     //save THAT
                     @THAT
                     D = M
                     @SP
                     A = M
                     M = D 
                     
                    //increment pointer
                    @SP
                    M = M + 1
                     //set new ARG address
                     
                    @1
                    D = A
                    @5
                    D = D + A
                    @SP
                    D = M - D
                    @ARG
                    M = D
                    
                     //set LCL Address
                     @SP
                     D = M
                     @LCL
                     M = D
                     @Main.fibonacci
                     0;JMP
                     (ReturnAddress-1)
                    
// label END  
(END)
// 	goto END                // loops infinitely

                @END
                0;JMP
             
// function Main.fibonacci 0

                      (Main.fibonacci)
                      
                        
// 	push argument 0

                     
                    @0
                    D=A
                     //Get value
                     @ARG
                     A = M + D
                     D = M
                     //put value in stack
                     @SP
                     A = M
                     M = D
                     
                    //increment pointer
                    @SP
                    M = M + 1
// 	push constant 2

                        @2
                        D=A
                        @SP
                        A = M
                        M = D
                        
                    //increment pointer
                    @SP
                    M = M + 1
// 	lt                     

                      
                    
                    //retrieve first value
                    
                    //Decrement pointer
                    @SP
                    M = M - 1
                    A=M
                    D=M
                    //retrieve second value
                    @SP
                    
                    //Decrement pointer
                    @SP
                    M = M - 1
                    A=M
                    
                    //calculate dif
                    D = M - D
                    @LESSTHAN1
                    D;JLT
                    
                    //result is false
                    @0
                    D=A
                    @SP
                     A = M
                     M = D 
                     
                    //increment pointer
                    @SP
                    M = M + 1
                    @ENDLESSTHAN1
                    0;JMP
                    (LESSTHAN1)
                    
                    //Result is true 
                    @0
                    D = A
                    D = D -1 
                    @SP
                     A = M
                     M = D 
                     
                    //increment pointer
                    @SP
                    M = M + 1
                    @ENDLESSTHAN1
                    0;JMP
                    (ENDLESSTHAN1)
                    
// 	if-goto N_LT_2        

                
                    //Decrement pointer
                    @SP
                    M = M - 1
                @SP
                A=M
                D=M
                @N_LT_2
                D;JLT
            
             
// 	goto N_GE_2

                @N_GE_2
                0;JMP
             
// label N_LT_2               // if n < 2 returns n
(N_LT_2)
// 	push argument 0        

                     
                    @0
                    D=A
                     //Get value
                     @ARG
                     A = M + D
                     D = M
                     //put value in stack
                     @SP
                     A = M
                     M = D
                     
                    //increment pointer
                    @SP
                    M = M + 1
// 	return

                      // RETURN
                     
                    //retrieve first value
                    
                    //Decrement pointer
                    @SP
                    M = M - 1
                    A=M
                    D=M
                     @ARG
                     A = M
                     M = D
                       
                    //Set Address To Return To R12
                    @5
                    D=A
                    @LCL
                    A = M - D
                    D = M
                    @R12
                    M = D
                    
                       
                    //Reposition THIS Address
                    @2
                    D=A
                    @LCL
                    A = M - D
                    D = M
                    @THIS
                    M = D
                                         
                       
                    //Reposition THAT Address
                    @1
                    D=A
                    @LCL
                    A = M - D
                    D = M
                    @THAT
                    M = D
                    
                       
                    //Reposition SP Address
                    @1
                    D=A
                    @ARG
                    D = M + D
                    @SP
                    M = D
                    
                       
                    //Reposition ARG Address
                    @3
                    D=A
                    @LCL
                    A = M - D
                    D = M
                    @ARG
                    M = D
                    
                       
                    //Reposition ARG Address
                    @4
                    D=A
                    @LCL
                    A = M - D
                    D = M
                    @LCL
                    M = D
                    
                     @R12
                     A = M
                     0;JMP
                    
// label N_GE_2               // if n >= 2 returns fib(n - 2) + fib(n - 1)
(N_GE_2)
// 	push argument 0

                     
                    @0
                    D=A
                     //Get value
                     @ARG
                     A = M + D
                     D = M
                     //put value in stack
                     @SP
                     A = M
                     M = D
                     
                    //increment pointer
                    @SP
                    M = M + 1
// 	push constant 2

                        @2
                        D=A
                        @SP
                        A = M
                        M = D
                        
                    //increment pointer
                    @SP
                    M = M + 1
// 	sub

                      
                    
                    //retrieve first value
                    
                    //Decrement pointer
                    @SP
                    M = M - 1
                    A=M
                    D=M
                    //retrieve second value
                    @SP
                    
                    //Decrement pointer
                    @SP
                    M = M - 1
                    A=M
                    M = M - D
                    
                    //increment pointer
                    @SP
                    M = M + 1
// 	call Main.fibonacci 1  // computes fib(n - 2)

                     //push return address
                     
                    @ReturnAddress-2
                    D=A
                    @SP
                     A = M
                     M = D 
                     
                    //increment pointer
                    @SP
                    M = M + 1
                     
                     //save LCL
                     @LCL
                     D = M
                     @SP
                     A = M
                     M = D 
                     
                    //increment pointer
                    @SP
                    M = M + 1
                    //save ARG 
                     @ARG
                     D = M
                     @SP
                     A = M
                     M = D 
                     
                    //increment pointer
                    @SP
                    M = M + 1
                    //save THIS
                     @THIS
                     D = M
                     @SP
                     A = M
                     M = D 
                     
                    //increment pointer
                    @SP
                    M = M + 1
                     //save THAT
                     @THAT
                     D = M
                     @SP
                     A = M
                     M = D 
                     
                    //increment pointer
                    @SP
                    M = M + 1
                     //set new ARG address
                     
                    @1
                    D = A
                    @5
                    D = D + A
                    @SP
                    D = M - D
                    @ARG
                    M = D
                    
                     //set LCL Address
                     @SP
                     D = M
                     @LCL
                     M = D
                     @Main.fibonacci
                     0;JMP
                     (ReturnAddress-2)
                    
// 	push argument 0

                     
                    @0
                    D=A
                     //Get value
                     @ARG
                     A = M + D
                     D = M
                     //put value in stack
                     @SP
                     A = M
                     M = D
                     
                    //increment pointer
                    @SP
                    M = M + 1
// 	push constant 1

                        @1
                        D=A
                        @SP
                        A = M
                        M = D
                        
                    //increment pointer
                    @SP
                    M = M + 1
// 	sub

                      
                    
                    //retrieve first value
                    
                    //Decrement pointer
                    @SP
                    M = M - 1
                    A=M
                    D=M
                    //retrieve second value
                    @SP
                    
                    //Decrement pointer
                    @SP
                    M = M - 1
                    A=M
                    M = M - D
                    
                    //increment pointer
                    @SP
                    M = M + 1
// 	call Main.fibonacci 1  // computes fib(n - 1)

                     //push return address
                     
                    @ReturnAddress-3
                    D=A
                    @SP
                     A = M
                     M = D 
                     
                    //increment pointer
                    @SP
                    M = M + 1
                     
                     //save LCL
                     @LCL
                     D = M
                     @SP
                     A = M
                     M = D 
                     
                    //increment pointer
                    @SP
                    M = M + 1
                    //save ARG 
                     @ARG
                     D = M
                     @SP
                     A = M
                     M = D 
                     
                    //increment pointer
                    @SP
                    M = M + 1
                    //save THIS
                     @THIS
                     D = M
                     @SP
                     A = M
                     M = D 
                     
                    //increment pointer
                    @SP
                    M = M + 1
                     //save THAT
                     @THAT
                     D = M
                     @SP
                     A = M
                     M = D 
                     
                    //increment pointer
                    @SP
                    M = M + 1
                     //set new ARG address
                     
                    @1
                    D = A
                    @5
                    D = D + A
                    @SP
                    D = M - D
                    @ARG
                    M = D
                    
                     //set LCL Address
                     @SP
                     D = M
                     @LCL
                     M = D
                     @Main.fibonacci
                     0;JMP
                     (ReturnAddress-3)
                    
// 	add                    // returns fib(n - 1) + fib(n - 2)

                      
                    
                    //retrieve first value
                    
                    //Decrement pointer
                    @SP
                    M = M - 1
                    A=M
                    D=M
                    //retrieve second value
                    @SP
                    
                    //Decrement pointer
                    @SP
                    M = M - 1
                    A=M
                    M = D + M
                    
                    //increment pointer
                    @SP
                    M = M + 1                    
                    
// 	return

                      // RETURN
                     
                    //retrieve first value
                    
                    //Decrement pointer
                    @SP
                    M = M - 1
                    A=M
                    D=M
                     @ARG
                     A = M
                     M = D
                       
                    //Set Address To Return To R12
                    @5
                    D=A
                    @LCL
                    A = M - D
                    D = M
                    @R12
                    M = D
                    
                       
                    //Reposition THIS Address
                    @2
                    D=A
                    @LCL
                    A = M - D
                    D = M
                    @THIS
                    M = D
                                         
                       
                    //Reposition THAT Address
                    @1
                    D=A
                    @LCL
                    A = M - D
                    D = M
                    @THAT
                    M = D
                    
                       
                    //Reposition SP Address
                    @1
                    D=A
                    @ARG
                    D = M + D
                    @SP
                    M = D
                    
                       
                    //Reposition ARG Address
                    @3
                    D=A
                    @LCL
                    A = M - D
                    D = M
                    @ARG
                    M = D
                    
                       
                    //Reposition ARG Address
                    @4
                    D=A
                    @LCL
                    A = M - D
                    D = M
                    @LCL
                    M = D
                    
                     @R12
                     A = M
                     0;JMP
                    

