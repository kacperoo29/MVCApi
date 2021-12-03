import React, { SetStateAction } from 'react'

type PaginationProps = {
    pageIndex: number,
    totalPages: number,
    hasNextPage: boolean,
    hasPreviousPage: boolean,
    setPage: React.Dispatch<SetStateAction<Number>>,
    setPageSize: React.Dispatch<SetStateAction<Number>>
}

export default function Pagination({ pageIndex, totalPages, hasNextPage, hasPreviousPage, setPage, setPageSize }: PaginationProps) {
    var current = pageIndex,
        last = totalPages,
        delta = 2,
        left = current - delta,
        right = current + delta + 1,
        range = [],
        rangeWithDots = [],
        l;

    for (let i = 1; i <= last; i++) {
        if (i === 1 || i === last || i >= left && i < right) {
            range.push(i);
        }
    }

    for (let i of range) {
        if (l) {
            if (i - l === 2) {
                rangeWithDots.push(l + 1);
            } else if (i - l !== 1) {
                rangeWithDots.push('...');
            }
        }
        rangeWithDots.push(i);
        l = i;
    }

    return (
        <nav>
            <ul className='pagination justify-content-center'>
                {hasPreviousPage &&
                    <li onClick={e => setPage(1)} className="page-item">
                        <a className="page-link">
                            <span aria-hidden="true">&laquo;</span>
                            <span className="sr-only">Previous</span>
                        </a>
                    </li>}
                {rangeWithDots.map((i, k) =>
                    <li onClick={e => {
                        if (typeof i === "number") setPage(i)
                    }} className="page-item" key={k}>
                        <a className="page-link">{i}</a>
                    </li>
                )}

                {hasNextPage &&
                    <li onClick={e => setPage(totalPages)} className="page-item">
                        <a className="page-link">
                            <span aria-hidden="true">&raquo;</span>
                            <span className="sr-only">Next</span>
                        </a>
                    </li>}
            </ul>
        </nav>
    )
}