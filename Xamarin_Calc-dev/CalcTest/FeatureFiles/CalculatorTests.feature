Feature: CalculatorTests
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

	As a user 
	I want to add two numbers 
	In order to know their sum
	
	As a user
	I want to subtract two numbers
	In order to know their difference
	
	As a user 
	I want to multiply two numbers 
	In order to know their product
	
	As a user 
	I want to divide two numbers 
	In order to know their quotient
	
	As a user 
	I want to see an error message if I misspelled a number input  
	In order to correct it

	As a user 
	I want to see an error message if I misspelled an operation sign 
	In order to understand what my mistake was

	As a user 
	I want to see an error if I divide a number by zero 
	So that the space-time continuum won’t collapse if I press the “Calculate” button
	
	As a user 
	I want a calculator to have delete button
	In order to clear previous result

	Background: 
	Given calculator app is initialized	

@addNum
Scenario Outline: Add two numbers
	Given the first number is <firstNumber>
	When I select a sign like plus
	When the second number is <secondNumber>
	And I tap on equal button
	Then the result should be <result>
	Examples:
    | firstNumber | secondNumber | result	  |
    |    0		  |   0			 |   0		  |
    |    1		  |   0			 |   1		  |
    |    0		  |   1			 |   1		  |
    |    9		  |   1			 |   10       |
    |    50		  |   50		 |   100	  |
	|    1000	  |   99000		 |   100000   |
	|    1		  |   999999	 |   1000000  |
	|    0.1	  |   0			 |   0.1	  |
	|    0.5	  |   0.5		 |   1		  |
	|    0.75	  |   0.25		 |   1		  |
	|    0.333	  |   0.25		 |   0.583	  |
	|    0.1000	  |   1.99		 |   2.09	  |
	|    2.77777  |   10.33		 |   13,10777 |
	|    0.9	  |   0.1		 |   1		  |


@multiplyNum
Scenario Outline: multiply two numbers
	Given the first number is <firstNumber>
	When I select a sign like multiply
	When the second number is <secondNumber>
	And I tap on equal button
	Then the result should be <result>
	Examples:
    | firstNumber | secondNumber | result     |
    | 0           | 0            | 0          |
    | 1           | 0            | 0          |
    | 0           | 1            | 0          |
    | 5           | 1            | 5          |
    | 7           | 2            | 14         |
    | 400         | 3            | 1200       |
    | 4           | 90000        | 360000     |
    | 600000      | 5            | 3000000    |
    | 0.5         | 0.5          | 0.25       |
    | 0.75        | 0.25         | 0.1875     |
    | 0.333       | 0.25         | 0.08325    |
    | 0.1000      | 1.99         | 0.0199     |
    | 2.77777     | 10.33        | 28.6943641 |
    | 0.9         | 0.1          | 0.09       |



@substract
Scenario Outline: Substract two numbers
	When The <first> number typed at the calculator
	When I tap on substract button
	When The <second> number typed at the calculator
	Then I see <first> and <second> numbers separated by substract operand
	When I tap on equal button
	Then I see the <result> of operation at the input field
	Examples: 
	| first | second | result | 
	| 6     | 3      | 3      |
	| 5     | 7      | -2     |
	| 4.5   | 2      | 2.5    |
	| 8     | 1.9    | 6.1    |
	| 0     | 5      | -5     |

@division
Scenario Outline: Division two numbers
	When The <first> number typed at the calculator
	When I tap on division button
	When The <second> number typed at the calculator
	Then I see <first> and <second> numbers separated by division operand
	When I tap on equal button
	Then I see the <result> of operation at the input field
	Examples: 
	| first | second | result            |
	| 10    | 5      | 2                 |
	| 9     | 6      | 1.5               |
	| 2     | 3      | 0.666666666666667 |
	| 0     | 15     | 0                 |
	| 5     | 2.5    | 2                 |

@negative
Scenario: Correct reacrion on division on zero
	When The 45 number typed at the calculator
	When I tap on division button
	When The 0 number typed at the calculator
	Then I see 45 and 0 numbers separated by division operand	
	When I tap on equal button
	Then I see informational error message

Scenario Outline: Zero as first operand after tap on operation button on initializing
	When I tap on <operation> button
	Then I see 0 and <operation> sign 
	When The 5 number typed at the calculator
	Then I see 0 and 5 numbers separated by <operation> sign
	When I tap on equal button
	Then I see the <result> of operation at the input field
	Examples: 
	| operation | result |
	| '+'         | 5      |
	| '-'         | -5     |
	| '*'         | 0      |
	| '/'         | 0      |