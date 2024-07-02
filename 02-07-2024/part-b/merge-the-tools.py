def get_sub_sequence(string):
    char_set = set()
    sub_sequence = ""
    
    for char in string:
        if (char not in char_set):
            char_set.add(char)
            sub_sequence += char
            
    return sub_sequence

def merge_the_tools(string, k):
    # your code goes here
    tempString = ""
    
    for i in range(len(string) + 1):
        if (len(tempString) == (len(string) / k)):
            # print(tempString)
            print(get_sub_sequence(tempString))
            
            if (i == len(string)):
                break
                
            tempString = string[i]
        else:
            tempString += string[i]
            
        

if __name__ == '__main__':
    string, k = input(), int(input())
    merge_the_tools(string, k)