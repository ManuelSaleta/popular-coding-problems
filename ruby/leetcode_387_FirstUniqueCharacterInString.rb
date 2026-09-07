def first_uniq_char(s)
  s.chars.each_with_index do |c, index|
    if s.count(c) == 1
      return index
    end
  end
  -1 
end


puts first_uniq_char "hhhhhhhhhhhhhhhhp"