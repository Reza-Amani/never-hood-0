class point(object):
    """description of class"""
    def __init__(self, X, Y):
        self.x = X 
        self.y = Y
        if X >= 1300:
            self.water = 4
        elif X >= 1100:
            self.water = 3
        elif X >= 800:
            self.water = 2
        else :
            self.water = 1



