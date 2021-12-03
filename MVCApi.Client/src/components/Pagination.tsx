import React from 'react'

type PaginationProps = {
    pageIndex: number,
    totalPages: number,
    hasNextPage: boolean,
    hasPreviousPage: boolean
}

export default function Pagination({  pageIndex, totalPages, hasNextPage, hasPreviousPage }: PaginationProps) {
    var current = pageIndex,
        last = totalPages,
        delta = 2,
        left = current - delta,
        right = current + delta + 1,
        range = [],
        rangeWithDots = [],
        l;

    for (let i = 1; i <= last; i++) {
        if (i == 1 || i == last || i >= left && i < right) {
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
                    <li className="page-item">
                        <span aria-hidden="true">&laquo;</span>
                        <span className="sr-only">Previous</span>
                    </li>}
                {rangeWithDots.map((i, k) => 
                    <li className="page-item" key={k}>
                        <span className="page-link">{i}</span>
                    </li>
                )}

                {hasNextPage &&
                    <li className="page-item">
                        <span aria-hidden="true">&raquo;</span>
                        <span className="sr-only">Next</span>
                    </li>}
            </ul>
        </nav>
    )
}