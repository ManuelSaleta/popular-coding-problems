
a = [1,3,4]
b = [4,3,1]

def compareTriplets(a, b)
    aPoints = 0
    bPoints = 0
    i = 0
    len = a.length()
    len.times {
        if a[i] > b[i]
            aPoints += 1
        end 
        if a[i] < b[i]
            bPoints += 1
        end
        i += 1
    }
    return [aPoints, bPoints]
end

results =  compareTriplets a,b

puts results.join " " 