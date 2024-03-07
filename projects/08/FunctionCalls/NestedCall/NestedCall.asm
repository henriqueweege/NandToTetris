// function Sys.init 0

                      (Sys.init)
                      
                        
// 	push constant 4000	// tests that THIS and THAT are handled correctly

                        @4000	//
                        D=A
                        @SP
                        A = M
                        M = D
                        
                    //increment pointer
                    @SP
                    M = M + 1
// 	pop pointer 0

                    //pop this
                    @SP
                    M = M - 1
                    A=M
                    D=M
                    @THIS
                    M=D
// 	push constant 5000

                        @5000
                        D=A
                        @SP
                        A = M
                        M = D
                        
                    //increment pointer
                    @SP
                    M = M + 1
// 	pop pointer 1

                    //pop that
                    @SP
                    M = M - 1
                    A=M
                    D=M
                    @THAT
                    M=D
// 	call Sys.main 0

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
                     
                    @0
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
                     @Sys.main
                     0;JMP
                     (ReturnAddress-1)
                    
// 	pop temp 1

                    //get address
                    
                    @1
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
// 	label LOOP
(LOOP)
// 	goto LOOP

                @LOOP
                0;JMP
             
// function Sys.main 5

                      (Sys.main)
                      
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
                                      

                                      //initialize local vars
                                      @2
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
                                      @3
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
                                      @4
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
                                      

                        
// 	push constant 4001

                        @4001
                        D=A
                        @SP
                        A = M
                        M = D
                        
                    //increment pointer
                    @SP
                    M = M + 1
// 	pop pointer 0

                    //pop this
                    @SP
                    M = M - 1
                    A=M
                    D=M
                    @THIS
                    M=D
// 	push constant 5001

                        @5001
                        D=A
                        @SP
                        A = M
                        M = D
                        
                    //increment pointer
                    @SP
                    M = M + 1
// 	pop pointer 1

                    //pop that
                    @SP
                    M = M - 1
                    A=M
                    D=M
                    @THAT
                    M=D
// 	push constant 200

                        @200
                        D=A
                        @SP
                        A = M
                        M = D
                        
                    //increment pointer
                    @SP
                    M = M + 1
// 	pop local 1

                    //get address
                    
                    @1
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
// 	push constant 40

                        @40
                        D=A
                        @SP
                        A = M
                        M = D
                        
                    //increment pointer
                    @SP
                    M = M + 1
// 	pop local 2

                    //get address
                    
                    @2
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
// 	push constant 6

                        @6
                        D=A
                        @SP
                        A = M
                        M = D
                        
                    //increment pointer
                    @SP
                    M = M + 1
// 	pop local 3

                    //get address
                    
                    @3
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
// 	push constant 123

                        @123
                        D=A
                        @SP
                        A = M
                        M = D
                        
                    //increment pointer
                    @SP
                    M = M + 1
// 	call Sys.add12 1

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
                     @Sys.add12
                     0;JMP
                     (ReturnAddress-2)
                    
// 	pop temp 0

                    //get address
                    
                    @0
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
// 	push local 2

                     
                    @2
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
// 	push local 3

                     
                    @3
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
// 	push local 4

                     
                    @4
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
                    
// function Sys.add12 0

                      (Sys.add12)
                      
                        
// 	push constant 4002

                        @4002
                        D=A
                        @SP
                        A = M
                        M = D
                        
                    //increment pointer
                    @SP
                    M = M + 1
// 	pop pointer 0

                    //pop this
                    @SP
                    M = M - 1
                    A=M
                    D=M
                    @THIS
                    M=D
// 	push constant 5002

                        @5002
                        D=A
                        @SP
                        A = M
                        M = D
                        
                    //increment pointer
                    @SP
                    M = M + 1
// 	pop pointer 1

                    //pop that
                    @SP
                    M = M - 1
                    A=M
                    D=M
                    @THAT
                    M=D
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
// 	push constant 12

                        @12
                        D=A
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
                    

