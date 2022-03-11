import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { AdminSectionComponent } from './admin-section.component';

let component: AdminSectionComponent;
let fixture: ComponentFixture<AdminSectionComponent>;

describe('AdminSection component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ AdminSectionComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(AdminSectionComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});
