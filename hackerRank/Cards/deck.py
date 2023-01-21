import random
from hackerRank.Cards.card import Hand, Ranks, Suits, Card

class Deck:

    global deck

    def __init__(self):
        self.deck = []
        for suit in Suits.suits:
            for rank in Ranks.ranks:
                self.deck.append(Card(suit, rank))
        

    def shuffle(self):
        for card_index in range(0, len(self.deck)):
            index = random(0, len(self.deck))
            card_to_swap = self.deck[card_index]
            self.deck[card_index] = self.deck[index]
            self.deck[index] = card_to_swap


    def deal(self, cards, players):
        hands = []
        for _ in players:
            hand = Hand()
            for _ in cards:
                hand.add_card(self.deck.pop)
            hands.append(hand)
        return hands
