# @param {String} s
# @return {Integer}
def roman_to_int(s)
  # lets read array s from left to right
  index = s.length - 1
  right_val = s.length
  total = 0

  roman_symbols = {
      "I" => 1,
      "V" => 5,    # case 1: I before V = -1
      "X" => 10,   #  case 2: I before X = -1
      "L" => 50,   #  case 3: X before L = -10
      "C" => 100,  #  case 4: X before C = -10
      "D" => 500,  #  case 5: C before D = -100
      "M" => 1000, #  case 6: C before M = -100
  }

  #algorythm: If current val is X and previous is L or C subtract 10 from total
  # If current val is M or D and previous is C subtract 100 from total
  arr = s.split("")
  val_right_of_current = "W"
  while index >= 0
    current = arr[index]
    val_right_of_current = arr[index + 1]

    if current  == "I" && (val_right_of_current == "V")
      total += 4
      index -= 1
    elsif current == "I" && (val_right_of_current == "X")
      total += 9
      index -= 1
    elsif current == "X" && (val_right_of_current == "L")
      total += 40
      index -= 1
    elsif current == "X" && (val_right_of_current == "C")
      total += 90
      index -= 1
    elsif current == "C" && (val_right_of_current == "D")
      total += 400 
      index -= 1
    elsif current == "C" && (val_right_of_current == "M")
      total += 900
      index -= 1
    else
      puts "No match, current symbol is #{roman_symbols[current]}"
      total += roman_symbols[current]
    end
    index -= 1
  end
  total
end


puts roman_to_int("MCMXCIV")