from globals import *
from graphics import Image, Point
from world_handle import *


class CreatureSingleCell(object):
    """description of class"""
    def __init__(self, x, y, world_handle):
        self.x_ = x
        self.y_ = y
        self.world_handle_ = world_handle
        self.world_handle_.add_single_cell_to_grid(self, self.x_, self.y_)

        self.image_ = Image(Point(self.x_, self.y_), 1, 1)
        self.image_.setPixel(0, 0, 'DarkGreen')
        self.world_handle_.draw_image(self.image_)
