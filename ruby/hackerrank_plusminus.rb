#!/bin/ruby

# Given an array of integers, calculate the ratios of its elements that are positive, negative, and zero. Print the decimal value of each fraction on a new line with  places after the decimal.
# Note: This challenge introduces precision problems. The test cases are scaled to six decimal places, though answers with absolute error of up to are acceptable.
# Example

# There are  elements, two positive, two negative and one zero. Their ratios are ,  and . Results are printed as:
# 0.400000
# 0.400000
# 0.200000
# Function Description
# Complete the plusMinus function in the editor below.
# plusMinus has the following parameter(s):
# int arr[n]: an array of integers
# Print
# Print the ratios of positive, negative and zero values in the array. Each value should be printed on a separate line with  digits after the decimal. The function should not return a value.
# Input Format
# The first line contains an integer, , the size of the array.
# The second line contains  space-separated integers that describe .
# Constraints


# Output Format
# Print the following  lines, each to  decimals:
# proportion of positive values
# proportion of negative values
# proportion of zeros
# Sample Input

require 'json'
require 'stringio'

#
# Complete the 'plusMinus' function below.
#
# The function accepts INTEGER_ARRAY arr as parameter.
#

def plusMinus(arr)
    # Write your code here
    posCounter = 0  
    negCounter = 0
    zeroCounter = 0
    len = arr.length + 0.0
    
    arr.each { |x|
        if x > 0
            posCounter += 1
        elsif x < 0
            negCounter += 1
        else x == 0
            zeroCounter += 1
        end    
    }
    
    puts (posCounter/len).round(6)
    puts (negCounter/len).round(6)
    puts (zeroCounter/len).round(6)
end

n = gets.strip.to_i

arr = gets.rstrip.split.map(&:to_i)

plusMinus(arr)
