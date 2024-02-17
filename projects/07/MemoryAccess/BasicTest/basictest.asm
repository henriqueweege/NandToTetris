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

                    //get address
                    
                    @0
                    D=A
                    @LCL
                    D=M+D
                    //store address at R13
                    @13
                    M=D
                    
                    //retrieve first value
                    
                    //Decrement pointer
                    @SP
                    M = M - 1
                    A=M
                    D=M
                    //put value at right address
                    @R13
                    A=M
                    M=D
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

                    //get address
                    
                    @2
                    D=A
                    @ARG
                    D=M+D
                    //store address at R13
                    @13
                    M=D
                    
                    //retrieve first value
                    
                    //Decrement pointer
                    @SP
                    M = M - 1
                    A=M
                    D=M
                    //put value at right address
                    @R13
                    A=M
                    M=D
// pop argument 1

                    //get address
                    
                    @1
                    D=A
                    @ARG
                    D=M+D
                    //store address at R13
                    @13
                    M=D
                    
                    //retrieve first value
                    
                    //Decrement pointer
                    @SP
                    M = M - 1
                    A=M
                    D=M
                    //put value at right address
                    @R13
                    A=M
                    M=D
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

                    //get address
                    
                    @6
                    D=A
                    @THIS
                    D=M+D
                    //store address at R13
                    @13
                    M=D
                    
                    //retrieve first value
                    
                    //Decrement pointer
                    @SP
                    M = M - 1
                    A=M
                    D=M
                    //put value at right address
                    @R13
                    A=M
                    M=D
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

                    //get address
                    
                    @5
                    D=A
                    @THAT
                    D=M+D
                    //store address at R13
                    @13
                    M=D
                    
                    //retrieve first value
                    
                    //Decrement pointer
                    @SP
                    M = M - 1
                    A=M
                    D=M
                    //put value at right address
                    @R13
                    A=M
                    M=D
// pop that 2

                    //get address
                    
                    @2
                    D=A
                    @THAT
                    D=M+D
                    //store address at R13
                    @13
                    M=D
                    
                    //retrieve first value
                    
                    //Decrement pointer
                    @SP
                    M = M - 1
                    A=M
                    D=M
                    //put value at right address
                    @R13
                    A=M
                    M=D
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

                    //get address
                    
                    @6
                    D=A
                    @TEMP
                    D=M+D
                    //store address at R13
                    @13
                    M=D
                    
                    //retrieve first value
                    
                    //Decrement pointer
                    @SP
                    M = M - 1
                    A=M
                    D=M
                    //put value at right address
                    @R13
                    A=M
                    M=D
// push local 0

                     
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
// push that 5

                     
                    @5
                    D=A
                     //Get value
                     @THAT
                     A = M + D
                     D = M
                     //put value in stack
                     @SP
                     A = M
                     M = D
                     
                    //increment pointer
                    @SP
                    M = M + 1
// add

                      
                    
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
                    
// push argument 1

                     
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
// sub

                      
                    
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
// push this 6

                     
                    @6
                    D=A
                     //Get value
                     @THIS
                     A = M + D
                     D = M
                     //put value in stack
                     @SP
                     A = M
                     M = D
                     
                    //increment pointer
                    @SP
                    M = M + 1
// push this 6

                     
                    @6
                    D=A
                     //Get value
                     @THIS
                     A = M + D
                     D = M
                     //put value in stack
                     @SP
                     A = M
                     M = D
                     
                    //increment pointer
                    @SP
                    M = M + 1
// add

                      
                    
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
                    
// sub

                      
                    
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
// push temp 6

                     
                    @6
                    D=A
                     //Get value
                     @TEMP
                     A = M + D
                     D = M
                     //put value in stack
                     @SP
                     A = M
                     M = D
                     
                    //increment pointer
                    @SP
                    M = M + 1
// add

                      
                    
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
                    

