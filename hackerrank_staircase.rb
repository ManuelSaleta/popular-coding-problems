# Staircase detail
# This is a staircase of size :
#    #
#   ##
#  ###
# ####
# Its base and height are both equal to n. It is drawn using # symbols and spaces. The last line is not preceded by any spaces.
# Write a program that prints a staircase of size n.
# Function Description
# Complete the staircase function in the editor below.
# staircase has the following parameter(s):
# int n: an integer
# Print
# Print a staircase as described above.
# Input Format
# A single integer,n, denoting the size of the staircase.
# Constraints
#  .
# Output Format
# Print a staircase of size  using # symbols and spaces.
# Note: The last line must have  spaces in it.
# Sample Input
# 6 
# Sample Output
#      #
#     ##
#    ###
#   ####
#  #####
# ######
# Explanation
# The staircase is right-aligned, composed of # symbols and spaces, and has a height and width of .


#!/bin/ruby

require 'json'
require 'stringio'

#
# Complete the 'staircase' function below.
#
# The function accepts INTEGER n as parameter.
#

def staircase(n)
    # Write your code here
    hash = '#'
    step = ''
    iter = 0
    n.times {
      if iter <= n
        step += hash
      end
      iter += 1
      puts step.rjust(n)
    }
end

n = gets.strip.to_i

staircase n
