def luhn_checksum(card_number):
    card_number = str(card_number)
    checksum = 0
    is_second_digit = False

    for digit in reversed(card_number):
        digit = int(digit)

        if is_second_digit:
            digit *= 2

        if digit > 9:
            digit -= 9

        checksum += digit

        is_second_digit = not is_second_digit

    return checksum % 10 == 0

def validate_credit_card(card_number):
    if luhn_checksum(card_number):
        print(f"{card_number} is a valid credit card number.")
    else:
        print(f"{card_number} is not a valid credit card number.")

validate_credit_card("4556737586899855")
validate_credit_card("1234567890123456")
