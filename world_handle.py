from globals import *
from graphics import *
from world import *


class WorldHandle(object):
    def __init__(self, world):
        self.world_ = world

    def add_single_cell_to_grid(self, single_cell, x, y):
        self.world_.grid_[x][y] = single_cell

    def draw_image(self, image):
        image.draw(self.world_.gui_.field)


