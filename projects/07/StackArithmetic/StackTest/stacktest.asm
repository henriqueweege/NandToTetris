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
                    D= D - M
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
                    @1
                    D=A
                    @SP
                    A=M
                    M=D
                    @ENDEQUAL1
                    0;JMP
                    (ENDEQUAL1)
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
                    D= D - M
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
                    @1
                    D=A
                    @SP
                    A=M
                    M=D
                    @ENDEQUAL2
                    0;JMP
                    (ENDEQUAL2)
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
                    D= D - M
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
                    @1
                    D=A
                    @SP
                    A=M
                    M=D
                    @ENDEQUAL3
                    0;JMP
                    (ENDEQUAL3)
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

                    @SP
                    A=M
                    D=M
                    @SP
                    M = M - 1
                    @SP
                    A=M
                    D= D - M
                    M=-1
                    @LESSTHAN1
                    D;JLT
                    @ENDLESSTHAN1
                    0;JMP
                    
                    (LESSTHAN1)
                    @SP
                    A=M
                    M=1
                    @ENDLESSTHAN1
                    0;JMP
                    (ENDLESSTHAN1)
                    
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

                    @SP
                    A=M
                    D=M
                    @SP
                    M = M - 1
                    @SP
                    A=M
                    D= D - M
                    M=-1
                    @LESSTHAN2
                    D;JLT
                    @ENDLESSTHAN2
                    0;JMP
                    
                    (LESSTHAN2)
                    @SP
                    A=M
                    M=1
                    @ENDLESSTHAN2
                    0;JMP
                    (ENDLESSTHAN2)
                    
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

                    @SP
                    A=M
                    D=M
                    @SP
                    M = M - 1
                    @SP
                    A=M
                    D= D - M
                    M=-1
                    @LESSTHAN3
                    D;JLT
                    @ENDLESSTHAN3
                    0;JMP
                    
                    (LESSTHAN3)
                    @SP
                    A=M
                    M=1
                    @ENDLESSTHAN3
                    0;JMP
                    (ENDLESSTHAN3)
                    
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

                    @SP
                    A=M
                    D=M
                    @SP
                    M = M - 1
                    @SP
                    A=M
                    D= D - M
                    M=-1
                    @GREATERTHAN1
                    D;JGT
                    @ENDGREATERTHAN1
                    0;JMP
                    (GREATERTHAN1)
                    @SP
                    A=M
                    M=1
                    @ENDGREATERTHAN1
                    0;JMP
                    (ENDGREATERTHAN1)
                   
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

                    @SP
                    A=M
                    D=M
                    @SP
                    M = M - 1
                    @SP
                    A=M
                    D= D - M
                    M=-1
                    @GREATERTHAN2
                    D;JGT
                    @ENDGREATERTHAN2
                    0;JMP
                    (GREATERTHAN2)
                    @SP
                    A=M
                    M=1
                    @ENDGREATERTHAN2
                    0;JMP
                    (ENDGREATERTHAN2)
                   
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

                    @SP
                    A=M
                    D=M
                    @SP
                    M = M - 1
                    @SP
                    A=M
                    D= D - M
                    M=-1
                    @GREATERTHAN3
                    D;JGT
                    @ENDGREATERTHAN3
                    0;JMP
                    (GREATERTHAN3)
                    @SP
                    A=M
                    M=1
                    @ENDGREATERTHAN3
                    0;JMP
                    (ENDGREATERTHAN3)
                   
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

                    @SP
                    M = M - 1
                    A=M
                    D=M
                    @SP
                    M = M - 1
                    @SP
                    A=M
                    M = M + D
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

                    @SP
                    A=M
                    D=M
                    @SP
                    M = M -1
                    @SP
                    A=M
                    D= M - D
// neg

                    @0
                    D=A
                    M = M - 1
                    A = M
                    M = D - M
                    @SP
                    M = M + 1
// and

                    @SP
                    A=M
                    D=M
                    @SP
                    M = M - 1
                    @SP
                    A=M
                    M= D & M
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

                    @SP
                    A=M
                    D=M
                    @SP
                    M = M - 1
                    @SP
                    A=M
                    M= D|M
                    @SP
                    M = M + 1
// not

                    @SP
                    M = M - 1
                    A=M
                    M=!M
                    @SP
                    M = M + 1

