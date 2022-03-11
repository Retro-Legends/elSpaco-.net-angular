import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { OfficeStatusComponent } from './office-status.component';

let component: OfficeStatusComponent;
let fixture: ComponentFixture<OfficeStatusComponent>;

describe('OfficeStatus component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ OfficeStatusComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(OfficeStatusComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});
