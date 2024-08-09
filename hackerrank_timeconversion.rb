# Given a time in -hour AM/PM format, convert it to military (24-hour) time.
# Note: - 12:00:00AM on a 12-hour clock is 00:00:00 on a 24-hour clock.
# - 12:00:00PM on a 12-hour clock is 12:00:00 on a 24-hour clock.
# Example

# Return '12:01:00'.

# Return '00:01:00'.
# Function Description
# Complete the timeConversion function in the editor below. It should return a new string representing the input time in 24 hour format.
# timeConversion has the following parameter(s):
# string s: a time in  hour format
# Returns
# string: the time in  hour format
# Input Format
# A single string  that represents a time in -hour clock format (i.e.:  or ).
# Constraints
# All input times are valid

#!/bin/ruby

require 'json'
require 'stringio'

#
# Complete the 'timeConversion' function below.
#
# The function is expected to return a STRING.
# The function accepts STRING s as parameter.
#

def timeConversion(s)
    # Uptimsed lin
    # DateTime.strptime(time_string, "%I:%M:%S%p").strftime("%H:%M:%S")
    
    # Write your code here
    time_chunks, meridiem = s.match(/(\d{2}:\d{2}:\d{2})(AM|PM)/i).captures
    time_chunks = time_chunks.split(':')
    hour = time_chunks[0]
    minute = time_chunks[1]
    second = time_chunks[2]
    second = second.gsub(/AM|PM/i, '')
    if meridiem == 'PM'
        hour = hour.to_i + 12 unless hour == '12'
    end
    if meridiem == 'AM' and hour.to_i == 12
        hour = '00'
    end
    
    "#{hour}:#{minute}:#{second}"
end

fptr = File.open(ENV['OUTPUT_PATH'], 'w')

s = gets.chomp

result = timeConversion s

fptr.write result
fptr.write "\n"

fptr.close()
