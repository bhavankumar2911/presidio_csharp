from itertools import permutations

str = input('Enter a string: ')
strPermutations = permutations(str)

for permutation in strPermutations:
    print("".join(permutation))