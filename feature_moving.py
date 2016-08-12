from random import *
class feature_moving(object):
    def __init__(self, creature):
        self.owner = creature
    def execute(self):
        pass
    def random_move_1p(self):
        (dx, dy) = choice([(0,0), (0,1), (0,-1), (1,0), (-1,0)])  
        self.owner.x = self.owner.x+dx
        self.owner.y = self.owner.y+dy
        self.owner.p.move(dx,dy)
        
    
