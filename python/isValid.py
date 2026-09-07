"""
    Problem : palingdrome of three symboles

    sudo code :
        S = string input()
        for every char in S:
            if char = { or [ or (:
                add char to stack
            if char = } or ] or )
                search stack and delete symbole
        if stack is empty
"""

def isValid(self, strInput):
    myStack = Stack()
    for c in strInput:
        if c == '(' || '{' || '[':
            myStack.push(c)
        if c == '}':
            myStack.pop('{')
        if c == ']':
            myStack.pop('{')
        if c == ')':
            myStack.pop('{')
    if isEmpty(myStack):
        return True
    else
        return False
