// push constant 10

                        @10
                        D=A
                        @SP
                        A = M
                        M = D
                        
                    //increment pointer
                    @SP
                    M = M + 1
// pop local 0

                    
                    @0
                    D=M
                    @LCL
                    A=M+D
                    M=D
                    
                    //Decrement pointer
                    @SP
                    M = M - 1
// push constant 21

                        @21
                        D=A
                        @SP
                        A = M
                        M = D
                        
                    //increment pointer
                    @SP
                    M = M + 1
// push constant 22

                        @22
                        D=A
                        @SP
                        A = M
                        M = D
                        
                    //increment pointer
                    @SP
                    M = M + 1
// pop argument 2

                    
                    @2
                    D=M
                    @ARG
                    A=M+D
                    M=D
                    
                    //Decrement pointer
                    @SP
                    M = M - 1
// pop argument 1

                    
                    @1
                    D=M
                    @ARG
                    A=M+D
                    M=D
                    
                    //Decrement pointer
                    @SP
                    M = M - 1
// push constant 36

                        @36
                        D=A
                        @SP
                        A = M
                        M = D
                        
                    //increment pointer
                    @SP
                    M = M + 1
// pop this 6

                    
                    @6
                    D=M
                    @THIS
                    A=M+D
                    M=D
                    
                    //Decrement pointer
                    @SP
                    M = M - 1
// push constant 42

                        @42
                        D=A
                        @SP
                        A = M
                        M = D
                        
                    //increment pointer
                    @SP
                    M = M + 1
// push constant 45

                        @45
                        D=A
                        @SP
                        A = M
                        M = D
                        
                    //increment pointer
                    @SP
                    M = M + 1
// pop that 5

                    
                    @5
                    D=M
                    @THAT
                    A=M+D
                    M=D
                    
                    //Decrement pointer
                    @SP
                    M = M - 1
// pop that 2

                    
                    @2
                    D=M
                    @THAT
                    A=M+D
                    M=D
                    
                    //Decrement pointer
                    @SP
                    M = M - 1
// push constant 510

                        @510
                        D=A
                        @SP
                        A = M
                        M = D
                        
                    //increment pointer
                    @SP
                    M = M + 1
// pop temp 6

                    
                    @6
                    D=M
                    @TEMP
                    A=M+D
                    M=D
                    
                    //Decrement pointer
                    @SP
                    M = M - 1
// push local 0

                     
                    @0
                    D=M
                     @LCL
                     A = M + D
                     D = M
                     @SP
                     A = M
                     M = D
                     
                    //increment pointer
                    @SP
                    M = M + 1
// push that 5

                     
                    @5
                    D=M
                     @THAT
                     A = M + D
                     D = M
                     @SP
                     A = M
                     M = D
                     
                    //increment pointer
                    @SP
                    M = M + 1
// add

                      
                    //retrieve first value
                    @SP
                    
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
                    
// push argument 1

                     
                    @1
                    D=M
                     @ARG
                     A = M + D
                     D = M
                     @SP
                     A = M
                     M = D
                     
                    //increment pointer
                    @SP
                    M = M + 1
// sub

                      
                    //retrieve first value
                    @SP
                    
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
// push this 6

                     
                    @6
                    D=M
                     @THIS
                     A = M + D
                     D = M
                     @SP
                     A = M
                     M = D
                     
                    //increment pointer
                    @SP
                    M = M + 1
// push this 6

                     
                    @6
                    D=M
                     @THIS
                     A = M + D
                     D = M
                     @SP
                     A = M
                     M = D
                     
                    //increment pointer
                    @SP
                    M = M + 1
// add

                      
                    //retrieve first value
                    @SP
                    
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
                    
// sub

                      
                    //retrieve first value
                    @SP
                    
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
// push temp 6

                     
                    @6
                    D=M
                     @TEMP
                     A = M + D
                     D = M
                     @SP
                     A = M
                     M = D
                     
                    //increment pointer
                    @SP
                    M = M + 1
// add

                      
                    //retrieve first value
                    @SP
                    
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
                    

