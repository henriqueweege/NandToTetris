
@17
D=A
@16
M=D
 
// push constant 111

                        @111
                        D=A
                        @SP
                        A = M
                        M = D
                        
                    //increment pointer
                    @SP
                    M = M + 1
// push constant 333

                        @333
                        D=A
                        @SP
                        A = M
                        M = D
                        
                    //increment pointer
                    @SP
                    M = M + 1
// push constant 888

                        @888
                        D=A
                        @SP
                        A = M
                        M = D
                        
                    //increment pointer
                    @SP
                    M = M + 1
// pop static 8

                    //get address
                    
                    @8
                    D=A
                    @16
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
// pop static 3

                    //get address
                    
                    @3
                    D=A
                    @16
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
// pop static 1

                    //get address
                    
                    @1
                    D=A
                    @16
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
// push static 3

                     
                    @3
                    D=A
                     //Get value
                     @16
                     A = M + D
                     D = M
                     //put value in stack
                     @SP
                     A = M
                     M = D
                     
                    //increment pointer
                    @SP
                    M = M + 1
// push static 1

                     
                    @1
                    D=A
                     //Get value
                     @16
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
// push static 8

                     
                    @8
                    D=A
                     //Get value
                     @16
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
                    

