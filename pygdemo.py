﻿import pygame
from pygame.locals import *
pygame.init()

  #! /usr/bin/env python

  # Move a single pixel around the screen without crashing against the borders.

  #import pygame

  # These are used for directions.
UP = (0, -1)
DOWN = (0, 1)
LEFT = (-1, 0)
RIGHT = (1, 0)

class MovingPixel:
     """ A moving pixel class. """

     def __init__(self, x, y):
         """ Creates a moving pixel. """
         self.x = x
         self.y = y
         self.hdir = 0
         self.vdir = -1

     def direction(self, dir):
         """ Changes the pixels direction. """
         self.hdir, self.vdir = dir

     def move(self):
         """ Moves the pixel. """
         self.x += self.hdir
         self.y += self.vdir

     def draw(self, surface):
         surface.set_at((self.x, self.y), (255, 255, 255))

 # Window dimensions.
width = 640
height = 400

screen = pygame.display.set_mode((width, height))
clock = pygame.time.Clock()
running = True
pixarray = []
 # Create a moving pixel.
for x in range(1,round(height/2)-2):
    pixarray.append(MovingPixel(x, round(height/2)))
#pix = MovingPixel(round(width/2), round(height/2))

screen.fill((0, 0, 0))
while running:
 #   screen.fill((0, 0, 0))
    for pix in pixarray:
        pix.move()

        if pix.x <= 0 or pix.x >= width or pix.y <= 0 or pix.y >= height:
            print ("Crash!")
            running = False
            pix.draw(screen)

    pygame.display.flip()
    for event in pygame.event.get():
         if event.type == pygame.QUIT:
             running = False
         elif event.type == pygame.KEYDOWN:
             if event.key == pygame.K_UP:
                 for pix in pixarray:
                    pix.direction(UP)
             elif event.key == pygame.K_DOWN:
                 for pix in pixarray:
                     pix.direction(DOWN)
             elif event.key == pygame.K_LEFT:
                 for pix in pixarray:
                     pix.direction(LEFT)
             elif event.key == pygame.K_RIGHT:
                 for pix in pixarray:
                     pix.direction(RIGHT)

    pygame.display.flip()
    clock.tick(120)

1  # ! /usr/bin/env python
2
3  # Move a single pixel around the screen without crashing against the borders.
4
5
import pygame

6
7  # These are used for directions.
8
UP = (0, -1)
9
DOWN = (0, 1)
10
LEFT = (-1, 0)
11
RIGHT = (1, 0)
12
13


class MovingPixel:
    14
    """ A moving pixel class. """


15
16


def __init__(self, x, y):
    17
    """ Creates a moving pixel. """


18
self.x = x
19
self.y = y
20
self.hdir = 0
21
self.vdir = -1
22
23


def direction(self, dir):
    24
    """ Changes the pixels direction. """


25
self.hdir, self.vdir = dir
26
27


def move(self):
    28
    """ Moves the pixel. """


29
self.x += self.hdir
30
self.y += self.vdir
31
32


def draw(self, surface):
    33
    surface.set_at((self.x, self.y), (255, 255, 255))


34
35  # Window dimensions.
36
width = 640
37
height = 400
38
39
screen = pygame.display.set_mode((width, height))
40
clock = pygame.time.Clock()
41
running = True
42
43  # Create a moving pixel.
44
pix = MovingPixel(width / 2, height / 2)
45
46
while running:
    47
    pix.move()
48
49
if pix.x <= 0 or pix.x >= width or pix.y <= 0 or pix.y >= height:
    50
    print
    "Crash!"
51
running = False
52
53
screen.fill((0, 0, 0))
54
pix.draw(screen)
55
56
for event in pygame.event.get():
    57
    if event.type == pygame.QUIT:
        58
    running = False
59 elif event.type == pygame.KEYDOWN:
60
if event.key == pygame.K_UP:
    61
    pix.direction(UP)
62 elif event.key == pygame.K_DOWN:
63
pix.direction(DOWN)
64 elif event.key == pygame.K_LEFT:
65
pix.direction(LEFT)
66 elif event.key == pygame.K_RIGHT:
67
pix.direction(RIGHT)
68
69
pygame.display.flip()
70
clock.tick(120)