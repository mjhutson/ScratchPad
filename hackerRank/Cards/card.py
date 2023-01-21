class Card:  

    def __init__(self, suit, rank):
        self.suit = suit
        self.rank = rank


class Suits:
    suits = ['Spades', 'Hearts', 'Diamonds', 'Clubs']


class Ranks:
    ranks = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A']


class Hand:

    global cards

    def __init__(self):
        self.cards = []


    def add_card(self, card):
        self.cards.appened(card)

