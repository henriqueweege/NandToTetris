// push constant 17

                        @17
                        D=A
                        @SP
                        A = M
                        M = D
                        @SP
                        M = M + 1
// push constant 17

                        @17
                        D=A
                        @SP
                        A = M
                        M = D
                        @SP
                        M = M + 1
// eq

                      
                    //retrieve first value
                    @SP
                    M = M - 1
                    A=M
                    D=M
                    //retrieve second value
                    @SP
                    M = M - 1
                    A=M
                    
                    //calculate dif
                    D = M - D
                    @EQUAL1
                    D;JEQ
                    
                    //result is false
                    @0
                    D=A
                    @SP
                    A=M
                    M=D
                    @ENDEQUAL1
                    0;JMP
                    (EQUAL1)
                    
                    //Result is true 
                    @0
                    D = A
                    D = D -1 
                    @SP
                    A = M
                    M = D
                    @ENDEQUAL1
                    0;JMP
                    (ENDEQUAL1)
                    
                    //increment pointer
                    @SP
                    M = M + 1 
// push constant 17

                        @17
                        D=A
                        @SP
                        A = M
                        M = D
                        @SP
                        M = M + 1
// push constant 16

                        @16
                        D=A
                        @SP
                        A = M
                        M = D
                        @SP
                        M = M + 1
// eq

                      
                    //retrieve first value
                    @SP
                    M = M - 1
                    A=M
                    D=M
                    //retrieve second value
                    @SP
                    M = M - 1
                    A=M
                    
                    //calculate dif
                    D = M - D
                    @EQUAL2
                    D;JEQ
                    
                    //result is false
                    @0
                    D=A
                    @SP
                    A=M
                    M=D
                    @ENDEQUAL2
                    0;JMP
                    (EQUAL2)
                    
                    //Result is true 
                    @0
                    D = A
                    D = D -1 
                    @SP
                    A = M
                    M = D
                    @ENDEQUAL2
                    0;JMP
                    (ENDEQUAL2)
                    
                    //increment pointer
                    @SP
                    M = M + 1 
// push constant 16

                        @16
                        D=A
                        @SP
                        A = M
                        M = D
                        @SP
                        M = M + 1
// push constant 17

                        @17
                        D=A
                        @SP
                        A = M
                        M = D
                        @SP
                        M = M + 1
// eq

                      
                    //retrieve first value
                    @SP
                    M = M - 1
                    A=M
                    D=M
                    //retrieve second value
                    @SP
                    M = M - 1
                    A=M
                    
                    //calculate dif
                    D = M - D
                    @EQUAL3
                    D;JEQ
                    
                    //result is false
                    @0
                    D=A
                    @SP
                    A=M
                    M=D
                    @ENDEQUAL3
                    0;JMP
                    (EQUAL3)
                    
                    //Result is true 
                    @0
                    D = A
                    D = D -1 
                    @SP
                    A = M
                    M = D
                    @ENDEQUAL3
                    0;JMP
                    (ENDEQUAL3)
                    
                    //increment pointer
                    @SP
                    M = M + 1 
// push constant 892

                        @892
                        D=A
                        @SP
                        A = M
                        M = D
                        @SP
                        M = M + 1
// push constant 891

                        @891
                        D=A
                        @SP
                        A = M
                        M = D
                        @SP
                        M = M + 1
// lt

                      
                    //retrieve first value
                    @SP
                    M = M - 1
                    A=M
                    D=M
                    //retrieve second value
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
                    A=M
                    M=D
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
                    @ENDLESSTHAN1
                    0;JMP
                    (ENDLESSTHAN1)
                    
                    //increment pointer
                    @SP
                    M = M + 1
// push constant 891

                        @891
                        D=A
                        @SP
                        A = M
                        M = D
                        @SP
                        M = M + 1
// push constant 892

                        @892
                        D=A
                        @SP
                        A = M
                        M = D
                        @SP
                        M = M + 1
// lt

                      
                    //retrieve first value
                    @SP
                    M = M - 1
                    A=M
                    D=M
                    //retrieve second value
                    @SP
                    M = M - 1
                    A=M
                    
                    //calculate dif
                    D = M - D
                    @LESSTHAN2
                    D;JLT
                    
                    //result is false
                    @0
                    D=A
                    @SP
                    A=M
                    M=D
                    @ENDLESSTHAN2
                    0;JMP
                    (LESSTHAN2)
                    
                    //Result is true 
                    @0
                    D = A
                    D = D -1 
                    @SP
                    A = M
                    M = D
                    @ENDLESSTHAN2
                    0;JMP
                    (ENDLESSTHAN2)
                    
                    //increment pointer
                    @SP
                    M = M + 1
// push constant 891

                        @891
                        D=A
                        @SP
                        A = M
                        M = D
                        @SP
                        M = M + 1
// push constant 891

                        @891
                        D=A
                        @SP
                        A = M
                        M = D
                        @SP
                        M = M + 1
// lt

                      
                    //retrieve first value
                    @SP
                    M = M - 1
                    A=M
                    D=M
                    //retrieve second value
                    @SP
                    M = M - 1
                    A=M
                    
                    //calculate dif
                    D = M - D
                    @LESSTHAN3
                    D;JLT
                    
                    //result is false
                    @0
                    D=A
                    @SP
                    A=M
                    M=D
                    @ENDLESSTHAN3
                    0;JMP
                    (LESSTHAN3)
                    
                    //Result is true 
                    @0
                    D = A
                    D = D -1 
                    @SP
                    A = M
                    M = D
                    @ENDLESSTHAN3
                    0;JMP
                    (ENDLESSTHAN3)
                    
                    //increment pointer
                    @SP
                    M = M + 1
// push constant 32767

                        @32767
                        D=A
                        @SP
                        A = M
                        M = D
                        @SP
                        M = M + 1
// push constant 32766

                        @32766
                        D=A
                        @SP
                        A = M
                        M = D
                        @SP
                        M = M + 1
// gt

                      
                    //retrieve first value
                    @SP
                    M = M - 1
                    A=M
                    D=M
                    //retrieve second value
                    @SP
                    M = M - 1
                    A=M
                    
                    //calculate dif
                    D = M - D
                    @GREATERTHAN1
                    D;JGT
                    
                    //result is false
                    @0
                    D=A
                    @SP
                    A=M
                    M=D
                    @ENDGREATERTHAN1
                    0;JMP
                    (GREATERTHAN1)
                    
                    //Result is true 
                    @0
                    D = A
                    D = D -1 
                    @SP
                    A = M
                    M = D
                    @ENDGREATERTHAN1
                    0;JMP
                    (ENDGREATERTHAN1)
                    
                    //increment pointer
                    @SP
                    M = M + 1 
                   
// push constant 32766

                        @32766
                        D=A
                        @SP
                        A = M
                        M = D
                        @SP
                        M = M + 1
// push constant 32767

                        @32767
                        D=A
                        @SP
                        A = M
                        M = D
                        @SP
                        M = M + 1
// gt

                      
                    //retrieve first value
                    @SP
                    M = M - 1
                    A=M
                    D=M
                    //retrieve second value
                    @SP
                    M = M - 1
                    A=M
                    
                    //calculate dif
                    D = M - D
                    @GREATERTHAN2
                    D;JGT
                    
                    //result is false
                    @0
                    D=A
                    @SP
                    A=M
                    M=D
                    @ENDGREATERTHAN2
                    0;JMP
                    (GREATERTHAN2)
                    
                    //Result is true 
                    @0
                    D = A
                    D = D -1 
                    @SP
                    A = M
                    M = D
                    @ENDGREATERTHAN2
                    0;JMP
                    (ENDGREATERTHAN2)
                    
                    //increment pointer
                    @SP
                    M = M + 1 
                   
// push constant 32766

                        @32766
                        D=A
                        @SP
                        A = M
                        M = D
                        @SP
                        M = M + 1
// push constant 32766

                        @32766
                        D=A
                        @SP
                        A = M
                        M = D
                        @SP
                        M = M + 1
// gt

                      
                    //retrieve first value
                    @SP
                    M = M - 1
                    A=M
                    D=M
                    //retrieve second value
                    @SP
                    M = M - 1
                    A=M
                    
                    //calculate dif
                    D = M - D
                    @GREATERTHAN3
                    D;JGT
                    
                    //result is false
                    @0
                    D=A
                    @SP
                    A=M
                    M=D
                    @ENDGREATERTHAN3
                    0;JMP
                    (GREATERTHAN3)
                    
                    //Result is true 
                    @0
                    D = A
                    D = D -1 
                    @SP
                    A = M
                    M = D
                    @ENDGREATERTHAN3
                    0;JMP
                    (ENDGREATERTHAN3)
                    
                    //increment pointer
                    @SP
                    M = M + 1 
                   
// push constant 57

                        @57
                        D=A
                        @SP
                        A = M
                        M = D
                        @SP
                        M = M + 1
// push constant 31

                        @31
                        D=A
                        @SP
                        A = M
                        M = D
                        @SP
                        M = M + 1
// push constant 53

                        @53
                        D=A
                        @SP
                        A = M
                        M = D
                        @SP
                        M = M + 1
// add

                      
                    //retrieve first value
                    @SP
                    M = M - 1
                    A=M
                    D=M
                    //retrieve second value
                    @SP
                    M = M - 1
                    A=M
                    M = D + M
                    
                    //increment pointer
                    @SP
                    M = M + 1                    
                    
// push constant 112

                        @112
                        D=A
                        @SP
                        A = M
                        M = D
                        @SP
                        M = M + 1
// sub

                      
                    //retrieve first value
                    @SP
                    M = M - 1
                    A=M
                    D=M
                    //retrieve second value
                    @SP
                    M = M - 1
                    A=M
                    M = M - D
                    
                    //increment pointer
                    @SP
                    M = M + 1
// neg

                    @0
                    D=A
                    @SP
                    M = M - 1
                    A=M
                    M = D - M
                    @SP
                    M = M + 1
// and

                      
                    //retrieve first value
                    @SP
                    M = M - 1
                    A=M
                    D=M
                    //retrieve second value
                    @SP
                    M = M - 1
                    A=M
                    M= D & M
                    
                    //increment pointer
                    @SP
                    M = M + 1   
                    
// push constant 82

                        @82
                        D=A
                        @SP
                        A = M
                        M = D
                        @SP
                        M = M + 1
// or

                      
                    //retrieve first value
                    @SP
                    M = M - 1
                    A=M
                    D=M
                    //retrieve second value
                    @SP
                    M = M - 1
                    A=M
                    M = D|M
                    
                    //increment pointer
                    @SP
                    M = M + 1
// not

                    @SP
                    M = M - 1
                    A=M
                    M=!M
                    @SP
                    M = M + 1

