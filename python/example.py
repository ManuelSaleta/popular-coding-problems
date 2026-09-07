def printStringPoperties(input):
    count =0
    finished = True

    if ( count <= len(input)-1):
        finished = False
        print (input[count])
        count = count + 2

    if(not finished):
        print (input[count])
        finished  = False


input = "123456"

print(printStringPoperties(input))
