from globals import *
from global_methods import *
from graphics import Image, Point
from world_handle import *
from random import *


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

    def live(self):
        (dx, dy) = choice([(0, 0), (0, 0), (0, 0), (0, 0), (0, 1), (0, -1), (1, 0), (-1, 0)])
        if not check_boundaries(self.x_+dx, self.y_+dy):
            (dx, dy) = (0, 0)

        self.owner.dx = dx
        self.owner.dy = dy


        if not self.world_handle_.check_vacancy_single_cell(self.x_ + dx, self.y_ + dy):
            (dx, dy) = (0, 0)

