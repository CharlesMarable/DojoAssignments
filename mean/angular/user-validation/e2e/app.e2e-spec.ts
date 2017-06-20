import { UserValidationPage } from './app.po';

describe('user-validation App', () => {
  let page: UserValidationPage;

  beforeEach(() => {
    page = new UserValidationPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
