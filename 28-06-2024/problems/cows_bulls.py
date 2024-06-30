def get_cows_and_bulls (secret, guess):
    if secret == guess:
        return "won"

    frequencies = [0] * 26
    cows, bulls = 0, 0

    for i in range(len(secret)):
        secret_character = secret[i]
        guess_character = guess[i]

        if secret_character == guess_character:
            bulls += 1

        frequencies[ord(secret_character) - 97] += 1
        frequencies[ord(guess_character) - 97] -= 1

    cows = len(secret) - bulls

    for frequency in frequencies:
        if frequency > 0:
            cows -= 1
    
    return f"{cows} cows {bulls} bulls"

print(get_cows_and_bulls("free", "erfe"))