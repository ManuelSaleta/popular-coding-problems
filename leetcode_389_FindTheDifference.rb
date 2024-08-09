# @param {String} s
# @param {String} t
# @return {Character}
def find_the_difference(s, t)
  if t.length == 1
      return t[0]
  end
  
  t.chars.each do |t2|
          if s.include?(t2) == false
              return t2
          end
  end
end

puts find_the_difference("a", "aa")