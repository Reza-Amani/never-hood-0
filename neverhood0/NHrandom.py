from random import random
from math import floor


class NHRandom:
    @staticmethod
    def get_int_0_9():
        while True:
            base = random()
            for r in range(0, 15):
                base *= 10
                digit = floor(base)
                yield digit
                base -= digit

