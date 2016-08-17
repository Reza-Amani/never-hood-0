from random import *
from feature import *
class feature_brain(object):
    """description of class"""
    def __init__(self, creature):
        feature.__init__(self, creature)
    def execute(self):
        pass
    def check_boundaries(self, nx, ny):
        if nx > 1300 or nx < 0 or ny > 600 or ny < 0 :
            return False
        else :
            return True
    def random_move_1p_inwater(self):
        if self.owner.grid[self.owner.x][self.owner.y].water > 1 : 
            (dx, dy) = choice([(0,0), (0,0), (0,0), (0,0), (0,1), (0,-1), (1,0), (-1,0)])  
            if not self.check_boundaries(self.owner.x+dx, self.owner.y+dy) :
                (dx, dy) = (0, 0)
        else:
            (dx,dy) = (0, 0)
        self.owner.dx = dx
        self.owner.dy = dy


