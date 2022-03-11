import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";

import { x2dVisualizerComponent } from './x2d-visualizer.component';

let component: x2dVisualizerComponent;
let fixture: ComponentFixture<x2dVisualizerComponent>;

describe('2dVisualizer component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ x2dVisualizerComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(x2dVisualizerComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});
