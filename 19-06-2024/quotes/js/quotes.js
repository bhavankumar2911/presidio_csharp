const quoteList = $("#quotes-list");
const previous = $("#previous");
const next = $("#next");
const loader = $("#loader");

async function fetchQuotes() {
  try {
    const response = await fetch("https://dummyjson.com/quotes");
    const quotes = (await response.json()).quotes;
    const noOfPages = quotes.length / 5;

    // hide loader
    loader.hide();

    // create pagination
    for (let i = noOfPages; i >= 1; i--) {
      const pageButtonTemplate = `
        <li class="page-item"><a class="page-link" href=${`http://127.0.0.1:5500/quotes.html?page=${i}`}>${i}</a></li>
    `;
      $(previous).after(pageButtonTemplate);
    }

    // getting page number
    const urlParams = new URLSearchParams(window.location.search);
    const pageNumber = urlParams.get("page");

    if (pageNumber < 1)
      window.location.replace(`http://127.0.0.1:5500/quotes.html?page=${1}`);
    if (pageNumber > noOfPages)
      window.location.replace(
        `http://127.0.0.1:5500/quotes.html?page=${noOfPages}`
      );

    const startIndex = (pageNumber - 1) * 5;
    const endIndex = startIndex + 4;

    // page navigation
    previous.click(() =>
      window.location.replace(
        `http://127.0.0.1:5500/quotes.html?page=${parseInt(pageNumber) - 1}`
      )
    );

    next.click(() =>
      window.location.replace(
        `http://127.0.0.1:5500/quotes.html?page=${parseInt(pageNumber) + 1}`
      )
    );

    // display quotes
    for (let i = startIndex; i <= endIndex; i++) {
      const quote = quotes[i];

      if (!quote) break;

      const template = `
            <li class="list-group-item">
                <figure>
                    <blockquote class="blockquote">
                    <p>${quote.quote}</p>
                    </blockquote>
                    <figcaption class="blockquote-footer">
                    Said by <cite title="Author">${quote.author}</cite>
                    </figcaption>
                </figure>
            </li>
        `;

      quoteList.append(template);
    }

    console.log(quotes);
  } catch (error) {
    console.error(error);
  }
}
fetchQuotes();
