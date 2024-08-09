#!/bin/ruby

require 'json'
require 'stringio'

#
# Complete the 'miniMaxSum' function below.
#
# The function accepts INTEGER_ARRAY arr as parameter.
#

def miniMaxSum(arr)
    # Write your code here
    largest_num = 0
    smallest_num = 1000000000 #gurantees we'll pick the next smallest
    largest_num_sum = 0
    smallest_num_sum = 0
    arr.each {  |n|
        if n > largest_num
            largest_num = n
        end
        if n <= smallest_num
            smallest_num = n
        end
    }

    arr.each {  |n|
        smallest_num_sum += n 
        largest_num_sum += n
    }
    
    print "#{smallest_num_sum - largest_num} #{largest_num_sum - smallest_num}"
end

arr = gets.rstrip.split.map(&:to_i)

miniMaxSum arr