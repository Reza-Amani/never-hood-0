from random import *
class feature_moving(object):
    def __init__(self, creature):
        self.owner_creature = creature

    def execute(self):
        (dx, dy) = choice([(0,0), (0,1), (0,-1), (1,0), (-1,0)])  
        self.owner_creature.x = self.owner_creature.x+dx
        self.owner_creature.y = self.owner_creature.y+dy
        self.owner_creature.p.move(dx,dy)
        
    
