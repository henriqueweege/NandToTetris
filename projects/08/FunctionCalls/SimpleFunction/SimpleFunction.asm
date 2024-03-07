// function SimpleFunction.test 2

                      (SimpleFunction.test)
                      
                                      //initialize local vars
                                      @0
                                      D=A
                                      @LCL
                                      D = M + D
                                      @R13
                                      M = D
                                      @0
                                      D = A
                                      @R13
                                      A = M 
                                      M = D
                                      
                    //increment pointer
                    @SP
                    M = M + 1
                                      

                                      //initialize local vars
                                      @1
                                      D=A
                                      @LCL
                                      D = M + D
                                      @R13
                                      M = D
                                      @0
                                      D = A
                                      @R13
                                      A = M 
                                      M = D
                                      
                    //increment pointer
                    @SP
                    M = M + 1
                                      

                        
// 	push local 0

                     
                    @0
                    D=A
                     //Get value
                     @LCL
                     A = M + D
                     D = M
                     //put value in stack
                     @SP
                     A = M
                     M = D
                     
                    //increment pointer
                    @SP
                    M = M + 1
// 	push local 1

                     
                    @1
                    D=A
                     //Get value
                     @LCL
                     A = M + D
                     D = M
                     //put value in stack
                     @SP
                     A = M
                     M = D
                     
                    //increment pointer
                    @SP
                    M = M + 1
// 	add

                      
                    
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
                    
// 	not

                    @SP
                    
                    //Decrement pointer
                    @SP
                    M = M - 1
                    A=M
                    M=!M
                    
                    //increment pointer
                    @SP
                    M = M + 1
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
// 	add

                      
                    
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
                    
// 	push argument 1

                     
                    @1
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
                    

